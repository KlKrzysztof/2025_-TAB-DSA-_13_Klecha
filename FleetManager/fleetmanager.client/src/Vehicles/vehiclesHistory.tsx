

function VehiclesHistory() {
    const panelStyle: React.CSSProperties = {
        height: '80vh',
        width: '30vw',
        backgroundColor: '#fff',
        borderRadius: '0 20px 20px 20px',
        display: 'flex',
        justifyContent: 'flex-start',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '20px'
    }

    const ListStyles: React.CSSProperties = {
        backgroundColor: '#dadada',
        width: '28vw',
        height: '70vh',
    }

    return <div style={panelStyle}>
        <h2>Vehicle history</h2>
        <div style={ListStyles}>
            
        </div>
    </div>
}

export default VehiclesHistory