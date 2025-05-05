import React from 'react'
import ListElement from "./ListElement"
//import useState from 'react'

/*const veh = {
    model: "Fiat Ducato",
    purpose: "Transit",
    plate: "STA 2I376P"
}*/

function VehiclesList() {

    //const [vehicles, setVehicles] = useState<any>([]);

    const ListStyles: React.CSSProperties = {
        backgroundColor: '#dadada',
        width: '28vw',
        height: '35vh',
    }

    const PanelStyles: React.CSSProperties = {
        height: '45vh',
        width: '30vw',
        backgroundColor: '#fff',
        borderRadius: '20px',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column'
    }

    return <div style={PanelStyles}>
        <h2>My Vehicles</h2>
        <div style={ListStyles}>
            <ListElement>vctdd</ListElement>
        </div>
    </div>
}

export default VehiclesList