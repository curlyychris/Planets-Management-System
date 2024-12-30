import {makeAutoObservable, runInAction} from 'mobx'
import { LoginDTO } from '../Models/login.dto';
import { UserDTO } from '../Models/user.dto';
import { apiClient } from '../API/apiClient';
import { ApiError } from '../Models/apiError';
import { RegisterDTO } from '../Models/register.dto';

class AuthStore{
    user:UserDTO|null=null;
    apiErrors:ApiError[]=[];
    hasError:boolean=false;
    userNameExists:boolean=false;
    emailExists:boolean=false;

    constructor()
    {
        makeAutoObservable(this);
        const userText=localStorage.getItem("user");
        if(userText)
        {
            this.user=JSON.parse(userText);
        }
    }

    logout(){
        localStorage.removeItem("user");
        this.user=null;        
    }

    async login(loginDTO:LoginDTO)
    {
        this.apiErrors=[];
        this.hasError=false;
        try {
            console.log("IM IN LOGIN TRY");
            const response=await apiClient.post<UserDTO>('/users/login',loginDTO);
            runInAction(()=>{
                this.user=response.data;   
                localStorage.setItem("user",JSON.stringify(this.user))             
            });
        } catch (error) {
            console.log("IM IN LOGIN CATCH");
            runInAction(()=>{
                this.hasError=true;
                this.apiErrors=error as ApiError[];
                throw Promise.reject();
            })
            console.log(error);            
        }
    }

    async register(registerDTO:RegisterDTO)
    {
        this.emailExists=false;
        this.userNameExists=false;

        this.apiErrors=[];
        try {
            await apiClient.post('/users/register',registerDTO);
        } catch (error) {
            runInAction(()=>{
                this.apiErrors=error as ApiError[];
                this.apiErrors.forEach(x=>{
                    if(x.name=="Email")
                    {
                        this.emailExists=true
                    }
                    if(x.name=="UserName")
                    {
                        this.userNameExists=true;
                    }
                })
                throw Promise.reject();
            })
            console.log(error);            
        }
    }
}
const authStore = new AuthStore();
export default authStore;