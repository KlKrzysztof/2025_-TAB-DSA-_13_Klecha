import { SortableTable } from "../SortableTable"

interface props {
    id: number | null
}

function VehiclesHistory({ id }: props) {
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

    const onSelect = (id: number | String) => {

    }

    return <div style={panelStyle}>
        <h2>Vehicle history</h2>
        {id != null ?
            <SortableTable fetchURL={`/api/reservation/get/vehicle/id/${id}`} idColumn="reservationId" onRowSelect={onSelect} visibleColumns={[{ key: "factualBeginDate", label: "Begin" }, { key: "factualEndDate", label: "End" }, { key: "privateUse", label: "Private use" }]} />
            : null
        }
    </div>
}

export default VehiclesHistory