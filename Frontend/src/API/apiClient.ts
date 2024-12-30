import axios, { AxiosError } from "axios"
import { ApiError } from "../Models/apiError";
import authStore from "../Stores/authStore";

export const apiClient=axios;
apiClient.defaults.baseURL="http://localhost:5078";
apiClient.interceptors.response.use(
    (response)=>{
        return response;
    },
    (error:AxiosError)=>{
        const apiErrors:ApiError[]=[];
        const errorData=error.response?.data;
        try {
            if(Array.isArray(errorData)){
                errorData.forEach(x=>{
                    apiErrors.push({
                        message:x.message,
                        name:x.name
                    })
                })
            } 
                        
        } catch (error) {
            
        }
        
       console.log(apiErrors);
        return Promise.reject(apiErrors);
    }
)
apiClient.interceptors.request.use(
    (config)=>{
        const token=authStore.user?.token;
        if(token)
        {
            config.headers.Authorization=`Bearer ${token}`;
        }
        return config;
    },
    (error)=>{
        return Promise.reject(error);
    }
);
