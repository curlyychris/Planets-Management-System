import React from "react";
import authStore from './authStore'
import planetsStore from './planetsStore'

export const storeContext=React.createContext({
    authStore,
    planetsStore,

});
export const useStore = () => React.useContext(storeContext);