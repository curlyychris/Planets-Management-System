export interface LoginFormData
{

    email:string,
    password:string,
}
export function getLoginDataDefaults():LoginFormData
{
    return {

        email:"",
        password:"",

    }
}