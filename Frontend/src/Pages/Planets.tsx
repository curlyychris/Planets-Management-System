import { useEffect, useState } from "react";
import { useStore } from "../Stores/storeContext";
import { observer } from 'mobx-react-lite';
import DataTable from "../Components/DataTable";
import { GridColDef } from "@mui/x-data-grid";
import { Fab } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import CreatePlanetForm from "../Components/CreatePlanetForm";
import { CreatePlanetFormData } from "../Models/createPlanetFormData";
import { CreatePlanetDto } from "../Models/createPlanet.dto";
import NavBar from "../Components/NavBar";
import { useNavigate } from "react-router";

export const Planets = observer(() => {
    const { planetsStore, authStore } = useStore();
    const [isFormOpen, setIsFormOpen] = useState(false);
    const navigate = useNavigate();



    useEffect(() => {
        planetsStore.loadPlanets();
    }, [planetsStore.loadPlanets])



    const columns: GridColDef[] =
        [
            { field: 'name', headerName: 'Name', width: 150 },
            { field: 'rotation_period', headerName: 'Rotation Period', width: 150 },
            { field: 'orbital_period', headerName: 'Orbital Period', width: 150 },
            { field: 'diameter', headerName: 'Diameter', width: 150 },
            { field: 'climate', headerName: 'Climate', width: 150 },
            { field: 'gravity', headerName: 'Gravity', width: 150 },
        ]

    function logout() {
        authStore.logout();
        navigate('/')
    }

    function createPlanet(createPlanetFormData: CreatePlanetFormData) {
        const createPlanetDto: CreatePlanetDto = {
            name: createPlanetFormData.name,
            rotation_period: createPlanetFormData.rotation_period,
            orbital_period: createPlanetFormData.orbital_period,
            diameter: createPlanetFormData.diameter,
            climate: createPlanetFormData.climate,
            gravity: createPlanetFormData.gravity,
        }
        planetsStore.createPlanet(createPlanetDto).then(() => setIsFormOpen(false));
    }



    return (
        <>
            <NavBar onLogout={logout}></NavBar>
            {/* rows={dummyPlanetsData} */}
            <DataTable columns={columns} paginationModel={{ page: 0, pageSize: 5 }} rows={planetsStore.planets}></DataTable>
            <Fab color="primary" aria-label="add"
                onClick={() => setIsFormOpen(true)}
                style={{
                    position: 'fixed',
                    bottom: 16,
                    right: 16,
                }}>
                <AddIcon />
            </Fab>

            {isFormOpen && <div className="absolute top-0 bottom-0 left-0 right-0 bg-black bg-opacity-75 flex justify-center pt-11">
                <div className="w-[600px]">
                    <CreatePlanetForm onClose={() => setIsFormOpen(false)} onCreate={createPlanet}></CreatePlanetForm>
                </div>

            </div>}

        </>

    )

});
