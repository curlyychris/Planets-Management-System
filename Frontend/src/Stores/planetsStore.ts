import { makeAutoObservable, runInAction } from "mobx";
import { apiClient } from "../API/apiClient";
import { PlanetsDto } from "../Models/planets.dto";
import { CreatePlanetDto } from "../Models/createPlanet.dto";

class PlanetsStore {
    planets: PlanetsDto[] = [];
    constructor() {
        makeAutoObservable(this);
    }
    loadPlanets=async ()=> {
        try {
            const response = await apiClient.get<PlanetsDto[]>('/planets');
            runInAction(()=>{
                this.planets=response.data
                console.log(response.data);
            });
        } catch (error) {
            console.log("Cant load planets....")
        }
    }

    createPlanet=async (createPlanetDto:CreatePlanetDto)=> {
        try {
            const response = await apiClient.post<PlanetsDto>('/planets',createPlanetDto);
            runInAction(()=>{
                
                this.planets=[response.data,...this.planets]
            });
        } catch (error) {
            console.log("Cant load planets....")
        }
    }
}
const planetsStore = new PlanetsStore();
export default planetsStore;
