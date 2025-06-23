import React, { useEffect, useState } from 'react';


interface ColumnDef {
    key: string;
    label: string;
}
interface TableProps {
    fetchURL: string;
    idColumn: string;
    onRowSelect: (id: number | string) => void;
    visibleColumns?: ColumnDef[];
}


interface DataItem {
    [key: string]: any;
    id: number | string;
}

export const SortableTable: React.FC<TableProps> = ({ fetchURL, idColumn, onRowSelect, visibleColumns }) => {
    const [data, setData] = useState<DataItem[]>([]);
    const [sortedField, setSortedField] = useState<string | null>(null);
    const [sortDirection, setSortDirection] = useState<'asc' | 'desc'>('asc');
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch(fetchURL);
            const json = await response.json();
            setData(json);
        };
        fetchData();
    }, [fetchURL]);

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
