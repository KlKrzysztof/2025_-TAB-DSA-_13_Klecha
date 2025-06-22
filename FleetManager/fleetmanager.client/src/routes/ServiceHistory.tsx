import React from 'react';
import { SortableTable } from '../SortableTable'
import { useState } from 'react'
import { useParams } from 'react-router-dom';

function ServiceHistory() {
    const { vehicleId } = useParams();

    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh',
        display: 'flex',
        justifyContent: 'center',
        flexDirection: 'row'
    }
    const PanelStyles: React.CSSProperties = {
        height: '80vh',
        width: '60vw',
        backgroundColor: '#ffffff',
        borderRadius: '10px 10px 10px 10px',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '10px'
    }
    const visibleColumns = [
        { key: 'serviceOperationsId', label: 'service ID' },
        { key: 'name', label: 'name of service' },
        { key: 'date', label: 'date' },
        { key: 'cost', label: 'cost' },
        { key: 'caretakeId', label: 'caretakeId' }
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

    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    const handleVehicleSelect = (id: number | string) => {
        setSelectedId(id);
    };
    return (
        <main style={ContentStyle}>


            <div style={PanelStyles}>
                <h2>service history of vehicle</h2>
                { }
                <SortableTable
                    fetchURL={`/api/serviceoperation/get/vehicle/id/${vehicleId}`}
                    //fetchURL={`/api/serviceoperations/get/all`}
                    idColumn="serviceOperationsId"
                    onRowSelect={handleVehicleSelect}
                    visibleColumns={visibleColumns} />
            </div>



        </main>
    );
};

export default ServiceHistory;