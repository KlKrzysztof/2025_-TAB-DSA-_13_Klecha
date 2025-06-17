import React, { useEffect, useState } from 'react';
import { SortableTable } from './SortableTable';

interface CompProps {
    linkEmployeeId: number;
    onClose: () => void;
}

interface ContactInfo {
    contactId: number;
    employeeId: number;
    telNumber: string;
}

export const ContactInfo: React.FC<CompProps> = ({ linkEmployeeId, onClose }) => {
    const [selectedId, setSelectedId] = useState<number | string | null>(null);
    const [selectedContact, setSelectedContact] = useState<ContactInfo>();

    const [forceRefresh, setForceRefresh] = useState<number>(0);


    const triggerForceRefresh = () => {
        setForceRefresh(forceRefresh + 1);
        console.log('Force refresh triggered');
    };

    const handleContactSelect = (id: number | string) => {
        setContact(id);
    };

    const handleAddContact = () => {
        // Implement the logic to add a new Contact
        console.log('Add Contact');

        fetch(`api/contact/create`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ ...selectedContact, contactId: 0}),
        })
        .then(response => {
            if (response.ok) {
                console.log('Contact added successfully');
                triggerForceRefresh(); // Trigger a refresh after adding
            } else {
                console.error('Error adding Contact');
            }
        });


    };

    const handleDeleteContact = () => {
        // Implement the logic to delete the selected Contact
        if (selectedId) {
            console.log(`Delete Contact with ID: ${selectedId}`);
            fetch(`api/contact/delete/id/${selectedId}`, {
                method: 'DELETE',
            })
                .then(response => {
                    if (response.ok) {
                        console.log('Contact deleted successfully');
                        setSelectedId(null); // Clear selected ID after deletion
                        setSelectedContact(undefined);// Clear selected Contact after deletion
                        triggerForceRefresh(); // Trigger a refresh after deletion
                    } else {
                        console.error('Error deleting Contact');
                    }
                });
        } else {
            console.log('No Contact selected for deletion');
        }
    };

    function handleUpdateContact(contact: ContactInfo){

        // Implement the logic to update the selected Contact
        if (selectedId) {
            console.log(`Update Contact with ID: ${selectedId}`);
            fetch(`api/contact/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(contact)
            })
            .then(response => {
                if (response.ok) {
                    console.log('Contact updated successfully');
                    triggerForceRefresh(); // Trigger a refresh after updating
                } else {
                    console.error('Error updating Contact');
                }
            });
        } else {
            console.log('No Contact selected for update');
        }
    };

    function handleUpdateContact(){

        // Implement the logic to update the selected Contact
        if (selectedId) {
            console.log(`Update Contact with ID: ${selectedId}`);
            fetch(`api/contact/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(selectedContact)
            })
                .then(response => {
                    if (response.ok) {
                        console.log('Contact updated successfully');
                        triggerForceRefresh(); // Trigger a refresh after updating
                    } else {
                        console.error('Error updating Contact');
                    }
                });
        } else {
            console.log('No Contact selected for update');
        }
    };



    const handleLinkContact = () => {
        if (selectedId) {
            if (selectedContact?.employeeId !== null && selectedContact?.employeeId !== undefined && selectedContact?.employeeId !== 0)
                console.log(`Contact with ID: ${selectedId} is already linked to employee with ID: ${selectedContact.employeeId}`);
            else
                console.log(`Link Contact with ID: ${selectedId} to employee with ID: ${linkEmployeeId}`);

            //verify employee id
            if (linkEmployeeId === undefined || linkEmployeeId === null || linkEmployeeId === 0) {
                console.error('Employee ID is not valid');
                return;
            }
            const newContact = selectedContact;
            newContact.employeeId = linkEmployeeId;
            setSelectedContact(newContact);
            handleUpdateContact(newContact);
        } else {
            console.log('No Contact selected for linking');
        }
    };
    async function setContact(id: number | string) {
        setSelectedId(id);
        console.log(`Contact with ID: ${id} selected`);
        // Fetch and display Contact details based on the selected ID
        // Implement the logic to fetch Contact details based on the selected ID
        const response = await fetch(`api/contact/get/id/${id}`);
        const data = await response.json();
        setSelectedContact(data);
    };
    return (
        <div>
        <div className= "card" >

    {/* Contact Details Panel */ }
        < div className = "details-panel" >

            <div className="form-grid" >
                <input type = "text"    placeholder = "Phone number"    value = { selectedContact?.telNumber ?? ""} onChange = { e => setSelectedContact({ ...selectedContact, telNumber: e.target.value }) } />
            </div>
            < div className = "button-group" >
                < button className = "add" onClick = { handleAddContact } > Add Contact </button>
                < button className = "delete" onClick = { handleDeleteContact } > Delete Contact </button>
                < button className = "update" onClick = { handleUpdateContact } > Update Contact </button>
                < button className = "link" onClick = { handleLinkContact } > Link Contact </button>
            </div>
            < button onClick = { onClose } > Close </button>
        </div>

        {/* Contact List Panel */ }
        <div className="list-panel" >
            <h1 className="title" > Contact List </h1>
                < div className = "employee-list" >
                    <SortableTable fetchURL="api/contact/get/all" idColumn = "contactId" onRowSelect = { handleContactSelect } refreshOnChange = { forceRefresh } />
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