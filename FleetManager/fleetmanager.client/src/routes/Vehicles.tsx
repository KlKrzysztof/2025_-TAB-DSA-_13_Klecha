
import VehiclesList from './VehiclesList'

function Vehicles() {

    const ContentStyle: React.CSSProperties = {
        marginTop: '3vh', 
        display: 'flex',
        justifyContent: 'center',
    }

    return (
        <main style={ContentStyle}>
            <VehiclesList/>
        </main>
    )
}

export default Vehicles