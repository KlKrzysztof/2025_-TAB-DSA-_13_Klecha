import React from 'react';
import { SortableTable } from '../SortableTable'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom';

function Service() {
    const navigate = useNavigate();


    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh',
        display: 'flex',
        justifyContent: 'center',
        flexDirection: 'row'
    }
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
    }
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

    const [showRefuelModal, setShowRefuelModal] = useState(false);
    const [refuelData, setRefuelData] = useState({mileage: '', date: '', cost: ''});

    const handleVehicleSelect = (id: number | string) => {
        setSelectedId(id);
    };
    const handleVehicleSelect1 = (id: number | string) => {
        setSelectedId1(id);
    };
    const handleSendToService = () => {
        if (!selectedId) {
            alert("Please select a vehicle first.");
            return;
        }
        const serviceReason = window.prompt("sending placeholder:");
        if (!serviceReason) return;

        fetch(`/api/vehicle/vehicle/sendToService/${selectedId}`, { method: 'POST' })
            .then(() => setRefreshKey(prev => prev + 1));
 
    };
    const handleReturnFromService = () => {
        if (!selectedId1) {
            alert("Please select a vehicle first.");
            return;
        }
        const serviceReason = window.prompt("returning placeholder:");
        if (!serviceReason) return;

        fetch(`/api/vehicle/vehicle/returnFromService/${selectedId1}`, { method: 'POST' })
            .then(() => setRefreshKey(prev => prev + 1));
    };
    const handleRefuel = () => {
        if (!selectedId) {
            alert("Please select a vehicle first.");
            return;
        }
        setShowRefuelModal(true);
    };
    const handleRefuelSubmit = () => {
        const { mileage, date, cost } = refuelData;
        if (!mileage || !date || !cost) {
            alert("Please fill in all fields.");
            return;
        }


        // Example fetch
        fetch(`/api/refuel/create`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ mileage, date, cost })
        }).then(() => {
            setRefreshKey(prev => prev + 1);
            setShowRefuelModal(false);
            setRefuelData({ mileage: '', date: '', cost: '' });
        });
    };
    const handleHistory = () => {
        if (selectedId) {
            navigate(`/serviceHistory/${selectedId}`);
        } else if (selectedId1) {
            navigate(`/serviceHistory/${selectedId1}`);
        } else {
            alert("Please select a vehicle first.");
        }
    };

    return (
        <main style={ContentStyle}>


            <div style={PanelStyles}>
                <h2>Not in service</h2>
                { }
                <SortableTable
                    key={`notInService-${refreshKey}`}
                    fetchURL="/api/vehicle/vehicle/notInService"
                    idColumn="vehicleId"
                    onRowSelect={handleVehicleSelect}
                    visibleColumns={visibleColumns} />
            </div>

            <div style={ButtonContainerStyle}>
                <button style={ButtonStyle} onClick={handleSendToService}>Send to Service</button>
                <button style={ButtonStyle} onClick={handleReturnFromService}>Return from Service</button>
                <button style={ButtonStyle} onClick={handleRefuel}>Refuel</button>
                <button style={ButtonStyle} onClick={handleHistory}>Service history</button>
            </div>

            <div style={PanelStyles}>
                <h2>In service</h2>
                { }
                <SortableTable
                    key={`notInService-${refreshKey}`}
                    fetchURL="/api/vehicle/vehicle/inService"
                    idColumn="vehicleId"
                    onRowSelect={handleVehicleSelect1}
                    visibleColumns={visibleColumns} />

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


        </main>
    );
};

export default Service;