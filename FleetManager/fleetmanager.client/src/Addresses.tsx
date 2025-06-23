import React, { useEffect, useState } from 'react';
import { Table } from './Table';

interface CompProps {
    linkEmployeeId: number;
    onClose: () => void;
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

export const Addresses: React.FC<CompProps> = ({ linkEmployeeId, onClose }) => {
  const [selectedId, setSelectedId] = useState<number | string | null>(null);
  const [selectedAddress, setSelectedAddress] = useState<Address>();

  const [forceRefresh, setForceRefresh] = useState<number>(0);


    const triggerForceRefresh = () => {
        setForceRefresh(forceRefresh+1);
        console.log('Force refresh triggered');
    };

    const handleAddressSelect = (id: number | string) => {
        setAddress(id);
    };

    const handleAddAddress = () => {
        // Implement the logic to add a new address
        console.log('Add Address');
        
        fetch(`api/address/create`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ ...selectedAddress, addressId: 0, employeeId: null }),
        })
        .then(response => {
            if (response.ok) {
                console.log('Address added successfully');
                triggerForceRefresh(); // Trigger a refresh after adding
            } else {
                console.error('Error adding address');
            }
        });


    };

    const handleDeleteAddress = () => {
        // Implement the logic to delete the selected address
        if (selectedId) {
            console.log(`Delete Address with ID: ${selectedId}`);
            fetch(`api/address/delete/id/${selectedId}`, {
                method: 'DELETE',
            })
            .then(response => {
                if (response.ok) {
                    console.log('Address deleted successfully');
                    setSelectedId(null); // Clear selected ID after deletion
                    setSelectedAddress(undefined);// Clear selected address after deletion
                    triggerForceRefresh(); // Trigger a refresh after deletion
                } else {
                    console.error('Error deleting address');
                }
            });
        } else {
            console.log('No address selected for deletion');
        }
    };

    function handleUpdateAddress(address: Address|undefined){

        // Implement the logic to update the selected address
        if (selectedId) {
            console.log(`Update Address with ID: ${selectedId}`);
            fetch(`api/address/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(address)
            })
            .then(response => {
                if (response.ok) {
                    console.log('Address updated successfully');
                    triggerForceRefresh(); // Trigger a refresh after updating
                } else {
                    console.error('Error updating address');
                }
            });
        } else {
            console.log('No address selected for update');
        }
    };

    function handleUpdateAddress() {

        // Implement the logic to update the selected address
        if (selectedId) {
            console.log(`Update Address with ID: ${selectedId}`);
            fetch(`api/address/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(selectedAddress)
            })
                .then(response => {
                    if (response.ok) {
                        console.log('Address updated successfully');
                        triggerForceRefresh(); // Trigger a refresh after updating
                    } else {
                        console.error('Error updating address');
                    }
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
                console.log(`Link Address with ID: ${selectedId} to employee with ID: ${linkEmployeeId}`);

            //verify employee id
            if (linkEmployeeId === undefined || linkEmployeeId === null || linkEmployeeId === 0) {
                console.error('Employee ID is not valid');
                return;
            }
            const newAddress = selectedAddress;
            newAddress.employeeId = linkEmployeeId;
            setSelectedAddress(newAddress);
            handleUpdateAddress(newAddress);
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
    <div  >
        <div className= "card" style = {{alignItems: "stretch"}}>

            {/* Address Details Panel */ }
    < div className = "details-panel" >
        <h1 className="title" > Address Details </h1>
                
                <div className="form-grid" >
                    < input type = "text"   placeholder = "City"               value = { selectedAddress?.city ?? "" }                 onChange = { e => setSelectedAddress({ ...selectedAddress, city: e.target.value }) } />
                    < input type = "text"   placeholder = "Postal Code"        value = { selectedAddress?.postalCode ?? "" }           onChange = { e => setSelectedAddress({ ...selectedAddress, postalCode: e.target.value }) } />
                    < input type = "text"   placeholder = "Street"             value = { selectedAddress?.street ?? "" }               onChange = { e => setSelectedAddress({ ...selectedAddress, street: e.target.value }) } />
                    < input type = "number" placeholder = "House no."          value = { selectedAddress?.houseNumber ?? "" }          onChange = { e => setSelectedAddress({ ...selectedAddress, houseNumber: e.target.value }) } />
                    < input type = "number" placeholder = "Accomodation no."   value = { selectedAddress?.accommodationNumber ?? "" }  onChange = { e => setSelectedAddress({ ...selectedAddress, accommodationNumber: e.target.value === "" ? null : e.target.value }) } />
                </div>
                < div className = "button-group" >
                    < button className = "add" onClick = { handleAddAddress } >Add</button>
                    < button className = "update" onClick = { handleUpdateAddress } >Update</button>
                    < button className = "delete" onClick = { handleDeleteAddress } >Delete</button>
                    < button className = "config" onClick = { handleLinkAddress } >Link</button>
                </div>
                < button className="delete" style={{margin: "auto 0 0 auto"}}onClick = { onClose } >X</button>
            </div>

            {/* Address List Panel */ }
            <div className="list-panel" >
                <h1 className="title" > Address List </h1>
                < div className = "employee-list" >
    <Table fetchURL="api/address/get/all" idColumn = "addressId" onRowSelect = { handleAddressSelect } refreshOnChange = { forceRefresh } visibleColumns = { [{ key: "addressId", label: "ID" }, { key: "city", label: "City" }, { key: "street", label: "Street" }, { key: "postalCode", label: "ZIP" }, { key: "houseNumber", label: "No." }, { key: "accommodationNumber", label: "Acc. No." }, { key: "employeeId", label: "Emp. ID" },]} />
                </div>
            </div>

        </div>
    </div>);

};

// Just a simple inline style to simulate a modal background
const modalContentStyle: React.CSSProperties = {
  background: '#fff',
  padding: '20px',
  borderRadius: '8px',
  maxWidth: '500px',
  margin: '100px auto',
  boxShadow: '0 2px 10px rgba(0,0,0,0.3)',
};