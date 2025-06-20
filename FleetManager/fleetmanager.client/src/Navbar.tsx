import React from "react"
import { Link } from 'react-router-dom';


function Navbar() {
    const NavbarStyles: React.CSSProperties = {
        width: '100%',
        height: '10vh',
        display: 'flex',
        justifyContent: 'space-between',
        margin: '0',
        backgroundColor: '#fff',
        borderBottom: '2px #000 solid'
    }

    const MenuStyles: React.CSSProperties = {
        listStyle: 'none',
        display: 'flex',
        justifyContent: 'flex-end',
        textDecoration: 'none',
        width: '100%',
        textAlign: 'center',
        alignItems: 'center'
    }

    const LiStyles: React.CSSProperties = {
        width: '10vw',
        height: '10vh',
        fontSize: '30px',
        color: 'black',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center'
    }

    const LogoStyle: React.CSSProperties = {
        width: '40%',
        display: 'flex',
        margin: '0',
        justifyContent: 'flex-start',
        alignItems: 'center'
    }

    const NavStyle: React.CSSProperties = {
        width: '60%',
        display: 'flex',
        justifyContent: 'flex-end'
    }

    return <div style={NavbarStyles }>
        <h1 style={LogoStyle}>Fleet Manager</h1>
        <nav style={NavStyle}>
            <ul style={MenuStyles}>
                <li style={LiStyles}> <Link to="/vehicles" style={LiStyles}>Vehicles</Link> </li>
                <li style={LiStyles}> <Link to="/employees" style={LiStyles}>Employees</Link></li>
                <li style={LiStyles}> <Link to="/service" style={LiStyles}>Service</Link> </li>
                <li style={LiStyles}> <Link to="/#" style={LiStyles}>Reservation</Link> </li>
                <li style={LiStyles}> <Link to="/#" style={LiStyles}>Costs</Link> </li>
            </ul>
        </nav>
    </div>
}

export default Navbar