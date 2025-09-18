import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import AppRpc from './AppRpc.tsx'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <App/>
        <AppRpc/>
    </StrictMode>,
)
