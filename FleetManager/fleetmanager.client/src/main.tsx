import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Vehicles from './Vehicles'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <Vehicles />
  </StrictMode>,
)
