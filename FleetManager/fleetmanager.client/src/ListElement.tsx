import { ReactNode } from 'react'

interface Props {
    children: ReactNode;
}
function ListElement({ children }: Props) {

    const ListStyles: React.CSSProperties = {
        backgroundColor: '#dadada',
        width: '28vw',
        height: '35vh',
    }

    return <div style={ListStyles}>
        {children}
    </div>
}

export default ListElement