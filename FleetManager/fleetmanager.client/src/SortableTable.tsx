import React, { useEffect, useState } from 'react';

// This component is a sortable table that fetches data from an API and allows sorting and selection of rows.
// It is designed to be reusable for different datasets by passing the fetch URL and column definitions as props.


// This interface defines the structure of a column definition, which includes a key and a label.
//// The key is used to access the data in each row, and the label is displayed in the table header.
interface ColumnDef {
    key: string;
    label: string;
}

// This interface defines the props that the SortableTable component accepts.
// It includes the fetch URL for the data, the ID column to identify rows, a callback for row selection, and optional visible columns.
// The refreshOnChange prop is used to trigger a refresh of the table data.
interface TableProps {
    fetchURL: string;
    idColumn: string;
    onRowSelect: (id: number | string) => void;
    refreshOnChange?: number;
    visibleColumns?: ColumnDef[];
    
}

// This interface defines the structure of a data item in the table.
// Each item must have an id property, which can be a number or a string, and can have any other properties.
interface DataItem {
    [key: string]: any;
    id: number | string;
}

export const SortableTable: React.FC<TableProps> = ({ fetchURL, idColumn, onRowSelect, refreshOnChange, visibleColumns }) => {
    const [data, setData] = useState<DataItem[]>([]);
    const [sortedField, setSortedField] = useState<string | null>(null);
    const [sortDirection, setSortDirection] = useState<'asc' | 'desc'>('asc');
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    /*
    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch(fetchURL);
            const json = await response.json();
            setData(json);
        };
        fetchData();
    }, [fetchURL]);*/

    //function to refresh data from the API
    const refreshData = async () => {
        const response = await fetch(fetchURL);
        const json = await response.json();
        setData(json);
    };

    //automatically refresh data when the fetchURL changes and on component mount
    useEffect(() => {
        refreshData();
    }, [fetchURL, refreshOnChange]);

    const handleSort = (field: string) => {
        const direction = sortedField === field && sortDirection === 'asc' ? 'desc' : 'asc';
        const sortedData = [...data].sort((a, b) => {
            if (a[field] < b[field]) return direction === 'asc' ? -1 : 1;
            if (a[field] > b[field]) return direction === 'asc' ? 1 : -1;
            return 0;
        });
        setSortedField(field);
        setSortDirection(direction);
        setData(sortedData);
    };

    const handleRowClick = (id: number | string) => {
        setSelectedId(id);
        onRowSelect(id);
    };

    const headers = data.length > 0 ? visibleColumns ?? Object.keys(data[0]).map((key) => ({key,label:key})) : [];


    return (
        <div style={{ height: '100%', overflow: 'hidden', display: 'flex', flexDirection: 'column', border: '1px solid #ccc' }}>
            <div style={{ flex: '0 0 auto' }}>
                <table style={{ width: '100%', borderCollapse: 'collapse', tableLayout: 'fixed' }}>
                    <thead style={{ backgroundColor: '#f2f2f2' }}>
                        <tr>
                            {headers.map(({ key, label }) => (
                                <th
                                    key={key}
                                    onClick={() => handleSort(key)}
                                    style={{
                                        cursor: 'pointer',
                                        borderBottom: '1px solid #ddd',
                                        padding: '8px',
                                        textAlign: 'center',
                                        background: '#f2f2f2',
                                    }}
                                >
                                    {label}
                                    {sortedField === key ? (sortDirection === 'asc' ? ' ▲' : ' ▼') : ''}
                                </th>
                            ))}
                        </tr>
                    </thead>
                </table>
            </div>

            <div style={{ flex: '1 1 auto', overflowY: 'auto' }}>
                <table style={{ width: '100%', borderCollapse: 'collapse', tableLayout: 'fixed' }}>
                    <tbody>
                        {data.map((row) => {
                            const isSelected = selectedId === row[idColumn];
                            return (
                                <tr
                                    key={row[idColumn]}
                                    onClick={() => handleRowClick(row[idColumn])}
                                    style={{
                                        backgroundColor: isSelected ? '#d0e7ff' : 'white',
                                        cursor: 'pointer',
                                    }}
                                >
                                    {headers.map(({ key }) => (
                                        <td
                                            key={key}
                                            style={{
                                                borderBottom: '1px solid #eee',
                                                padding: '8px',
                                            }}
                                        >
                                            {row[key]}
                                        </td>
                                    ))}
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </div>

    );
};
