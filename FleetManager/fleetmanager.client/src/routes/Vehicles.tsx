
import { useState } from 'react'
import VehiclesList from '../Vehicles/VehiclesList'
import VehiclesHistory from '../Vehicles/vehiclesHistory'
import VehiclesRequests from '../Vehicles/VehiclesRequests'

function Vehicles() {

    const [id, setId] = useState < number | null>(null)

    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh', 
        display: 'flex',
        justifyContent: 'center',
        flexDirection: 'row'
    }

    const ContentColumn: React.CSSProperties = {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between'
    }

    const VehiclesRow: React.CSSProperties = {
        display: 'flex',
        justifyContent: 'flex-end',
        flexDirection: 'row'
    }

    const SelectVehicle = (id: number) => {
        setId(id)
    }

    return (
        <main style={ContentStyle}>
            <div style={ContentColumn}>
                <div style={VehiclesRow}>
                    <VehiclesList onSelect={SelectVehicle} />
                    
                </div>
                <VehiclesRequests />
            </div>
            <VehiclesHistory id={id} />
        </main>
    )
}

export default Vehicles