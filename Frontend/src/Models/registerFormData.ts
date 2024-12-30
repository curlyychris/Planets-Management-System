export interface RegisterFormData
{
    username:string,
    email:string,
    password:string,
    confirmPassword:string
}
export function getRegisterDataDefaults():RegisterFormData
{
    return {
        confirmPassword:"",
        email:"",
        password:"",
        username:""
    }
}