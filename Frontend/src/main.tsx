import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { storeContext } from './Stores/storeContext.ts';
import authStore from './Stores/authStore';
import planetsStore from './Stores/planetsStore.ts';

const stores={
  authStore,
  planetsStore,
};

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <storeContext.Provider value={stores}>
    <App />
    </storeContext.Provider>
  </StrictMode>,
);
