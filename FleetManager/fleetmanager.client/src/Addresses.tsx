import React, { useEffect, useState } from 'react';
import { SortableTable } from './SortableTable';
import { copyFile } from 'fs';
interface CompProps {
    onLinkToEmplyee: (id: number | string) => void;
}

interface Address {
    addressId: number;
    city: string;
    street: string;
    postalCode: string;
    houseNumber: number;
    accommodationNumber: number;
    employeeId: number;
}

export const Addresses: React.FC<CompProps> =  ({ onLinkToEmplyee }) => {
  const [selectedId, setSelectedId] = useState<number | string | null>(null);
  const [selectedAddress, setSelectedAddress] = useState<Address>();


    const handleAddressSelect = (id: number | string) => {
        setAddress(id);
    };

    const handleAddAddress = () => {
        // Implement the logic to add a new address
        console.log('Add Address');
    };

    const handleDeleteAddress = () => {
        // Implement the logic to delete the selected address
        if (selectedId) {
            console.log(`Delete Address with ID: ${selectedId}`);
        } else {
            console.log('No address selected for deletion');
        }
    };

    const handleUpdateAddress = () => {
        // Implement the logic to update the selected address
        if (selectedId) {
            console.log(`Update Address with ID: ${selectedId}`);
            fetch(`api/address/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(selectedAddress),
            })
            .then(response => response.json())
            .then(data => {
                console.log('Address updated successfully:', data);
            })
            .catch(error => {
                console.error('Error updating address:', error);
            });
        } else {
            console.log('No address selected for update');
        }
    };

    const handleLinkAddress = () => {
        if (selectedId) {
            if (selectedAddress?.employeeId !== null && selectedAddress?.employeeId !== undefined && selectedAddress?.employeeId !== 0)
            console.log(`Address with ID: ${selectedId} is already linked to employee with ID: ${selectedAddress.employeeId}`);
            else
            console.log(`Link Address with ID: ${selectedId}`);

            onLinkToEmplyee(selectedId);
        } else {
            console.log('No address selected for linking');
        }
    };
    async function setAddress(id: number | string) {
        setSelectedId(id);
        console.log(`Address with ID: ${id} selected`);
        // Fetch and display address details based on the selected ID
        // Implement the logic to fetch address details based on the selected ID
        const response = await fetch(`api/address/get/id/${id}`);
        const data = await response.json();
        setSelectedAddress(data);
    };
  return (
    <div className= "container" >
        <div className="card" >

            {/* Address Details Panel */ }
            < div className = "details-panel" >
                <div className="form-grid" >
                    <input type = "text" placeholder = "City"               value = { selectedAddress?.city ?? "" }                 onChange = { e => setSelectedAddress({ ...selectedAddress, city: e.target.value }) } />
                    <input type = "text" placeholder = "Postal Code"        value = { selectedAddress?.postalCode ?? "" }           onChange = { e => setFirstName(e.target.value) } />
                    <input type = "text" placeholder = "Street"             value = { selectedAddress?.street ?? "" }               onChange = { e => setFirstName(e.target.value) } />
                    <input type = "text" placeholder = "House no."          value = { selectedAddress?.houseNumber ?? "" }          onChange = { e => setFirstName(e.target.value) } />
                    <input type = "text" placeholder = "Accomodation no."   value = { selectedAddress?.accommodationNumber ?? "" }  onChange = { e => setFirstName(e.target.value) } />
                </div>
                < div className = "button-group" >
                    < button className = "add" onClick = { handleAddAddress } > Add Address </button>
                    < button className = "delete" onClick = { handleDeleteAddress } > Delete Address </button>
                    < button className = "update" onClick = { handleUpdateAddress } > Update Address </button>
                    < button className = "link" onClick = { handleLinkAddress } > Link Address </button>
                </div>
            </div>

            {/* Address List Panel */ }
            <div className="list-panel" >
                <h1 className="title" > Address List </h1>
                < div className = "employee-list" style = {{ maxHeight: "300px" } }>
                    <SortableTable fetchURL="api/address/get/all" idColumn = "addressId" onRowSelect = { handleAddressSelect } />
                </div>
            </div>

        </div>
    </div>);

};