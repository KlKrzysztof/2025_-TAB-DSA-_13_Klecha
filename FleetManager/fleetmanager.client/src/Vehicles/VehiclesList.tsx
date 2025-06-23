import React from 'react'
//import ListElement from "./ListElement"
import { SortableTable } from '../SortableTable'
import { useState } from 'react'
import VehiclesDetails from '../Vehicles/VehiclesDetails'

/*const veh = {
    model: "Fiat Ducato",
    purpose: "Transit",
    plate: "STA 2I376P"
}*/

interface props {
    onSelect: (id: number) => void
}

function VehiclesList({ onSelect } : props) {

    //const [vehiclesName] = useState('');
    const [selectedId, setSelectedId] = useState<number | null>(null);

    const handleVehicleSelect = (id: number | String) => {
        setSelectedId(Number(id));
        onSelect(Number(id))
        console.log(`Employee with ID: ${id} selected`);
    };

    const PanelStyles: React.CSSProperties = {
        height: '45vh',
        width: '30vw',
        backgroundColor: '#fff',
        borderRadius: '20px 0 0 20px',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '20px'
    }

    return <><div style={PanelStyles}>
        <h2>My Vehicles</h2>
        <SortableTable fetchURL="/api/vehicle/vehicle/all" idColumn="vehicleId" onRowSelect={handleVehicleSelect} visibleColumns={[{ key: "model", label: "Model" }, { key: "plateNumber", label: "Plate Number" }, { key: "vin", label: "VIN" }, { key: "vehiclePurpose", label: "Purpose" }]} />
    </div>
        <VehiclesDetails id={selectedId} />
    </>
}

export default VehiclesList