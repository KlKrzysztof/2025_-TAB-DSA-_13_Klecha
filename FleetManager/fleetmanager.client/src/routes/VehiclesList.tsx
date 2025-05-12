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

    const pStyle: React.CSSProperties = {
        width: '200px',
        margin: '0',
        textAlign: 'center'
    }

    return <div style={PanelStyles}>
        <h2>My Vehicles</h2>
        <div style={ListStyles}>
            <ListElement><p style={pStyle}>Fiat Ducato</p><p style={pStyle}>Dostawcze</p><p style={pStyle}>STA 2I376P</p></ListElement>
            <ListElement><p style={pStyle}>Renault Master</p><p style={pStyle}>Laweta</p><p style={pStyle}>SG 420PR</p></ListElement>
            <ListElement><p style={pStyle}>Ford Transit</p><p style={pStyle}>Dostawcze</p><p style={pStyle}>SY 6996I2</p></ListElement>
        </div>
    </div>
}

export default VehiclesList