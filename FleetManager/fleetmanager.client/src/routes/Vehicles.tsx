
import VehiclesList from './VehiclesList'
import Navbar from "./Navbar"

function Vehicles() {

    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh', 
        display: 'flex',
        justifyContent: 'center'
    }

    return (<>
        <Navbar />
        <main style={ContentStyle}>
            <VehiclesList/>
        </main>
    </>)
}

export default Vehicles