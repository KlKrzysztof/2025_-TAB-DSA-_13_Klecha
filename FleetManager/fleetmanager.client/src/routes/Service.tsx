import React from 'react';
import { SortableTable } from '../SortableTable';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Service() {
    const navigate = useNavigate();

    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh',
        display: 'flex',
        justifyContent: 'center',
        flexDirection: 'row'
    };
    const PanelStyles: React.CSSProperties = {
        height: '60vh',
        width: '35vw',
        backgroundColor: '#ffffff',
        borderRadius: '10px 10px 10px 10px',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '10px'
    };
    const visibleColumns = [
        { key: 'vehicleId', label: 'Vehicle ID' },
        { key: 'plateNumber', label: 'Plate Number' },
        { key: 'modelId', label: 'Model ID' },
        { key: 'model', label: 'Model' }
    ];
    const ButtonContainerStyle: React.CSSProperties = {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        gap: '1vh',
        margin: '0 1vw'
    };
    const ButtonStyle: React.CSSProperties = {
        padding: '5px 5px',
        borderRadius: '5px',
        border: 'none',
        backgroundColor: '#6161a1',
        width: '10vw',
        color: '#ffffff',
        cursor: 'pointer'
    };
    const RefuelMask: React.CSSProperties = {
        position: 'fixed',
        top: 0,
        left: 0,
        height: '100vh',
        width: '100vw',
        backgroundColor: 'rgba(0, 0, 0, 0.4)',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        zIndex: 1000
    };
    const RefuelStyle: React.CSSProperties = {
        backgroundColor: 'white',
        padding: '2rem',
        borderRadius: '10px',
        display: 'flex',
        flexDirection: 'column',
        gap: '1rem',
        minWidth: '300px'
    };

    const [refreshKey, setRefreshKey] = useState(0);
    const [selectedId, setSelectedId] = useState<number | string | null>(null);
    const [selectedId1, setSelectedId1] = useState<number | string | null>(null);
    const [caretakeId, setCaretakeId] = useState<number | null>(null);
    const [showRefuelModal, setShowRefuelModal] = useState(false);
    const [refuelData, setRefuelData] = useState({ mileage: '', date: '', cost: '' });

    //service operation modal
    const [showServiceModal, setShowServiceModal] = useState(false);
    const [serviceData, setServiceData] = useState({ name: '', date: '', cost: '' });

    const handleVehicleSelect = (id: number | string) => {
        setSelectedId(id);
    };
    const handleVehicleSelect1 = (id: number | string) => {
        setSelectedId(id);
        setSelectedId1(id);
    };
    const handleReturnFromService = () => {
        if (!selectedId1) {
            alert("Please select a vehicle first.");
            return;
        }
        fetch(`/api/vehicle/vehicle/returnFromService/${selectedId1}`, { method: 'POST' })
            .then(() => setRefreshKey(prev => prev + 1));
    };
    const handleHistory = () => {
        if (selectedId) {
            navigate(`/serviceHistory/${selectedId}`);
        } else {
            alert("Please select a vehicle first.");
        }
    };

    const fetchCaretakeId = () => {
        if (!selectedId) return Promise.reject("No selectedId");

        return fetch(`/api/caretake/get/vehicle/id/${selectedId}`)
            .then(res => res.json())
            .then(data => {
                const id = typeof data === 'number' ? data : data.caretakeId;
                setCaretakeId(id);
                return id; // return the id for chaining
            });
    };
    const handleRefuel = () => {
        if (!selectedId) {
            alert("Please select a vehicle first.");
            return;
        }
        setShowRefuelModal(true);
    };
    const handleRefuelSubmit = async () => {
        const { mileage, date, cost } = refuelData;

        if (!mileage || !date || !cost) {
            alert("Please fill in all fields.");
            return;
        }
        if (!selectedId) {
            alert("No vehicle selected.");
            return;
        }

        try {
            const id = await fetchCaretakeId();

            const payload = {
                refuelId: 0,
                currentMileage: Number(mileage),
                date: date,
                cost: Number(cost),
                caretakeId: id,
                reservationId: null
            };

            await fetch(`/api/refuel/create`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });

            setRefreshKey(prev => prev + 1);
            setShowRefuelModal(false);
            setRefuelData({ mileage: '', date: '', cost: '' });

        } catch (error) {
            alert("Failed to submit refuel data: " + error);
        }
    };
    const handleServiceSubmit = async () => {
        const { name, date, cost } = serviceData;

        if (!selectedId) {
            alert("Please select a vehicle first.");
            return;
        }
        fetch(`/api/vehicle/vehicle/sendToService/${selectedId}`, { method: 'POST' })
            .then(() => setRefreshKey(prev => prev + 1));
        if (!name || !date || !cost) {
            alert("Please fill in all fields.");
            return;
        }

        try {
            const id = await fetchCaretakeId();

            const payload = {
                serviceOperationsId: 0,
                name: name,
                date: date,
                cost: Number(cost),
                caretakeId: id,
                reservationId: null
            };

            await fetch(`/api/serviceOperation/create`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });

            setRefreshKey(prev => prev + 1);
            setShowServiceModal(false);
            setServiceData({ name: '', date: '', cost: '' });

        } catch (error) {
            alert("Failed to submit service operation: " + error);
        }
    };


    return (
        <main style={ContentStyle}>
            <div style={PanelStyles}>
                <h2>Not in service</h2>
                <SortableTable
                    key={`notInService-${refreshKey}`}
                    fetchURL="/api/vehicle/vehicle/notInService"
                    idColumn="vehicleId"
                    onRowSelect={handleVehicleSelect}
                    visibleColumns={visibleColumns}
                />
            </div>

            <div style={ButtonContainerStyle}>
                <button style={ButtonStyle} onClick={() => setShowServiceModal(true)}>Send to Service</button>
                <button style={ButtonStyle} onClick={handleReturnFromService}>Return from Service</button>
                <button style={ButtonStyle} onClick={handleRefuel}>Refuel</button>
                <button style={ButtonStyle} onClick={handleHistory}>Service history</button>
            </div>

            <div style={PanelStyles}>
                <h2>In service</h2>
                <SortableTable
                    key={`inService-${refreshKey}`}
                    fetchURL="/api/vehicle/vehicle/inService"
                    idColumn="vehicleId"
                    onRowSelect={handleVehicleSelect1}
                    visibleColumns={visibleColumns}
                />
            </div>

            {showRefuelModal && (
                <div style={RefuelMask}>
                    <div style={RefuelStyle}>
                        <h3>Refuel Vehicle</h3>
                        <input
                            type="number"
                            placeholder="Current Mileage"
                            value={refuelData.mileage}
                            onChange={(e) => setRefuelData({ ...refuelData, mileage: e.target.value })}
                        />
                        <input
                            type="date"
                            value={refuelData.date}
                            onChange={(e) => setRefuelData({ ...refuelData, date: e.target.value })}
                        />
                        <input
                            type="number"
                            placeholder="Cost"
                            value={refuelData.cost}
                            onChange={(e) => setRefuelData({ ...refuelData, cost: e.target.value })}
                        />
                        <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                            <button style={ButtonStyle} onClick={handleRefuelSubmit}>Submit</button>
                            <button style={{ ...ButtonStyle, backgroundColor: '#aaa' }} onClick={() => setShowRefuelModal(false)}>Cancel</button>
                        </div>
                    </div>
                </div>
            )}

            {showServiceModal && (
                <div style={RefuelMask}>
                    <div style={RefuelStyle}>
                        <h3>Add Service Operation</h3>
                        <input
                            type="text"
                            placeholder="Service Name"
                            value={serviceData.name}
                            onChange={(e) => setServiceData({ ...serviceData, name: e.target.value })}
                        />
                        <input
                            type="date"
                            value={serviceData.date}
                            onChange={(e) => setServiceData({ ...serviceData, date: e.target.value })}
                        />
                        <input
                            type="number"
                            placeholder="Cost"
                            value={serviceData.cost}
                            onChange={(e) => setServiceData({ ...serviceData, cost: e.target.value })}
                        />
                        <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                            <button style={ButtonStyle} onClick={handleServiceSubmit}>Submit</button>
                            <button style={{ ...ButtonStyle, backgroundColor: '#aaa' }} onClick={() => setShowServiceModal(false)}>Cancel</button>
                        </div>
                    </div>
                </div>
            )}
        </main>
    );
}

export default Service;
