import { useEffect, useState } from 'react';

// This component is a sortable table that fetches data from an API and allows sorting and selection of rows.
// It is designed to be reusable for different datasets by passing the fetch URL and column definitions as props.


// This interface defines the structure of a column definition, which includes a key and a label.
//// The key is used to access the data in each row, and the label is displayed in the table header.
interface ColumnDef {
    key: string;
    label: string;
}

// This interface defines the props that the SortableTable component accepts.
// It includes the table data, the ID column to identify rows, a callback for row selection, and optional visible columns.
// The refreshOnChange prop is used to trigger a refresh of the table data.
interface TableProps {
    data: DataItem[];
    idColumn: string;
    onRowSelect?: (id: number | string) => void;
    visibleColumns?: ColumnDef[];

}

// This interface defines the structure of a data item in the table.
// Each item must have an id property, which can be a number or a string, and can have any other properties.
interface DataItem {
    [key: string]: any;
    id: number | string;
}

export const DataTable: React.FC<TableProps> = ({ data, idColumn, onRowSelect, visibleColumns }) => {
    //const [data, setData] = useState<DataItem[]>([]);
    const [sortedField, setSortedField] = useState<string | null>(null);
    const [sortDirection, setSortDirection] = useState<'asc' | 'desc'>('asc');
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    /*
    //automatically refresh when the data changes and on component mount
    useEffect(() => {
        setData(tableData);
    }, [tableData, refreshOnChange]);
    */
    const handleSort = (field: string) => {
        const direction = sortedField === field && sortDirection === 'asc' ? 'desc' : 'asc';
        const sortedData = [...data].sort((a, b) => {
            if (a[field] < b[field]) return direction === 'asc' ? -1 : 1;
            if (a[field] > b[field]) return direction === 'asc' ? 1 : -1;
            return 0;
        });
        setSortedField(field);
        setSortDirection(direction);
        data = sortedData;
    };

    const handleRowClick = (id: number | string) => {
        setSelectedId(id);
        onRowSelect?.(id);
    };

    const headers = data.length > 0 ? visibleColumns ?? Object.keys(data[0]).map((key) => ({ key, label: key })) : [];

    return (
        <div className = "table-outer" style = {{ overflowX: 'auto', height: '100%', border: '1px solid #ccc', backgroundColor: '#ddd' }
}>
    <table style={ { width: '100%', borderCollapse: 'separate', borderSpacing: '0' } }>
        <thead style={ { position: 'sticky', top: '0' } }>
            <tr style={ { cursor: 'pointer' } }>
            {
                headers.map(({ key, label }) => (
                    <th style= {{ padding: '5px', whiteSpace: 'nowrap', borderRight: '1px solid #ccc', textAlign: 'left', background: '#ddd', borderBottom: '2px solid #ccc' }}
key = { key }
onClick = {() => handleSort(key)}
                            >
    { label }
{ sortedField === key ? (sortDirection === 'asc' ? ' ▲' : ' ▼') : '' }
</th>
                        ))}
</tr>
    </thead>
    <tbody>
{
    data.map((row, index) => {
        const isSelected = selectedId === row[idColumn];
        return (
            <tr
                                key= { row[idColumn]}
        onClick = {() => handleRowClick(row[idColumn])
    }
                                style = { isSelected? { background: '#d0e7ff', cursor: 'pointer' } : index % 2 == 0 ? { background: '#ebeaea', cursor: 'pointer' } : { background: '#fff', cursor: 'pointer' }}
                            >
{
    headers.map(({ key }) => (
        <td style= {{ padding: '5px', whiteSpace: 'nowrap', borderRight: '1px solid #ccc', borderBottom: '1px solid #ccc' }} key = { key } >
            { row[key]}
            </td>
                                ))}
</tr>
                        );
                    })}
</tbody>
    </table>
    </div>
    );
};

export default DataTable;