
import React from 'react'
import VehiclesDetails from '../Vehicles/VehiclesDetails'
import VehiclesList from '../Vehicles/VehiclesList'
import VehiclesHistory from '../Vehicles/vehiclesHistory'
import VehiclesRequests from '../Vehicles/VehiclesRequests'

function Vehicles() {

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

    return (
        <main style={ContentStyle}>
            <div style={ContentColumn}>
                <div style={VehiclesRow}>
                    <VehiclesList />
                    <VehiclesDetails />
                </div>
                <VehiclesRequests />
            </div>
            <VehiclesHistory/>
        </main>
    )
}

export default Vehicles