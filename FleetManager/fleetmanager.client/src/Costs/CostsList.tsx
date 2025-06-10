import React, { useState } from 'react';
import { SortableTable } from '../SortableTable';

interface Refuel {
    refuelId: number;
    currentMileage: number;
    date: Date;
    cost: number;
    caretakeId: number;
    reservationId: number;
}

const Refuel: React.FC = () => {
    const [selectedRefuel, setSelectedRefuel] = useState<Refuel>();
    const [, setSelectedId] = useState<number | string | null>(null);
    const handleRefuelSelect = (id: number | string) => {
        setRefuel(id);
    };
    async function setRefuel(id: number | string) {
        setSelectedId(id);
        console.log(`Employee with ID: ${id} selected`);
        // Fetch and display employee details based on the selected ID
        // Implement the logic to fetch employee details based on the selected ID
        const response = await fetch(`api/refuel/get/id/${id}`);
        const data = await response.json();
        setSelectedRefuel(data);
    };

    return (
        <div className="container">
            <div className="card">
                {/* Employee Details Panel */}
                {/*<div className="details-panel">*/}
                {/*    <input type="text" value={selectedRefuel?.refuelId + " "} readOnly className="name-heading" />*/}

                {/*</div>*/}
                {/* Employees List Panel */}
                <div className="list-panel">
                    <h1 className="title">Refuel List</h1>
                    <div className="employee-list" style={{ maxHeight: "300px" }}>
                        <SortableTable fetchURL="api/refuel/get/all" idColumn="refuelId" onRowSelect={handleRefuelSelect}
                            visibleColumns=
                            {[
                                { key: "refuelId", label: "Id tankowania" },
                                { key: "currentMileage", label: "Obecny przebieg" },
                                { key: "date", label: "Data tankowania" },
                            ]} />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Refuel;
