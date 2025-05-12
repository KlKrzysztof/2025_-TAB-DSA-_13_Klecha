import { ReactNode, useState } from 'react'

interface Props {
    children: ReactNode;
}
function ListElement({ children }: Props) {

    var [Mouse, setMouse] = useState(false)

    const ListStyles: React.CSSProperties = {
        backgroundColor: '#fff',
        width: '100%',
        height: '30px',
        borderTop: '2px #adadad solid',
        borderBottom: '2px #adadad solid',
        marginTop: '10px',
        display: 'inline-flex',
        justifyContent: 'space-between'
    }

    const ListStylesHover: React.CSSProperties = {
        backgroundColor: '#ddd',
        width: '100%',
        height: '30px',
        borderTop: '2px #bdbdbd solid',
        borderBottom: '2px #bdbdbd solid',
        marginTop: '10px',
        display: 'inline-flex',
        justifyContent: 'space-between',
        cursor: 'pointer'
    }

    return <div style={Mouse ? ListStylesHover : ListStyles} onMouseEnter={() => setMouse(true)} onMouseLeave={() => setMouse(false)}>
        {children}
    </div>
}

export default ListElement