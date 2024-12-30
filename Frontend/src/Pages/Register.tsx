import { useState } from "react";
import { Link, useNavigate } from "react-router";
import * as yup from "yup";
import { observer } from 'mobx-react-lite';
import { useStore } from '../Stores/storeContext';
import { getRegisterDataDefaults } from "../Models/registerFormData";
import { getYupErrorMessages } from "../Utilities/yupUtils";
import { RegisterDTO } from "../Models/register.dto";


const registerValidator=yup.object().shape({
    username:yup.string().required("Username is required"),
    email:yup.string().email("Invalid email").required("Email is required"),
    password:yup
    .string()
    .matches(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
        "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character"
      )
    .required("Password is required"),
    confirmPassword:yup
    .string()
    .oneOf([yup.ref("password")],"Passwords must match")
    .required("Confirm password is required"),
});

export const Register=observer(()=> {
    const [registerFormData,setRegisterFormData]=useState(getRegisterDataDefaults())
    const [errors,setErrors]=useState(new Map<string,string>());
    const { authStore } = useStore();
    const navigate = useNavigate();

    const handleChange=(e: React.ChangeEvent<HTMLInputElement>)=>{
        const {name,value}=e.target;
        setRegisterFormData((prevData)=>{
            return {...prevData,[name]:value}
        })
    };

    const register=async (e:React.FormEvent<HTMLFormElement>)=>{
        e.preventDefault();    
        const validation=await getYupErrorMessages(registerValidator,registerFormData);   
        if(validation.size!=0)
        {
            setErrors(validation);
        }
        else{
            const registerDto:RegisterDTO={email:registerFormData.email,password:registerFormData.password,username:registerFormData.username}
            authStore.register(registerDto).then(()=>{
                navigate('/');
            });
            setErrors(new Map());
        }
        console.log(validation);
    }

    return (
        <div className="flex items-center justify-center min-h-screen ">
            <div className="w-full max-w-md p-8 space-y-6 bg-white rounded-lg shadow-lg">
                <h2 className="text-2xl font-bold text-center text-gray-800">Register</h2>
                <form onSubmit={register} className="space-y-4">
                    <div>
                        <label htmlFor="username" className="block text-sm font-medium text-gray-700">Username</label>
                        <input
                            type="text"
                            name="username"
                            id="username"
                            value={registerFormData.username}
                            onChange={handleChange}

                            className="w-full px-3 py-2 mt-1 border rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"  
                        />
                        {errors.get("username") && <p className="text-red-500 text-sm">{errors.get("username")}</p>}
                        {authStore.userNameExists && <p className="text-red-500 text-sm">Username already exists</p>}
                    </div>
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">Email</label>
                        <input
                            name="email"
                            id="email"
                            value={registerFormData.email}
                            onChange={handleChange}
                            className="w-full px-3 py-2 mt-1 border rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"  
                        />
                        {errors.get("email") && <p className="text-red-500 text-sm">{errors.get("email")}</p>}
                        {authStore.emailExists && <p className="text-red-500 text-sm">Email already exists</p>}
                    </div>
                    <div>
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
                        <input
                            type="password"
                            name="password"
                            id="password"
                            value={registerFormData.password}
                            onChange={handleChange}
                            className="w-full px-3 py-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                        />
                        {errors.get("password") && <p className="text-red-500 text-sm">{errors.get("password")}</p>}
                    </div>
                    <div>
                        <label htmlFor="confirmPassword" className="block text-sm font-medium text-gray-700">Confirm Password</label>
                        <input
                            type="password"
                            name="confirmPassword"
                            id="confirmPassword"
                            value={registerFormData.confirmPassword}
                            onChange={handleChange}
                            className="w-full px-3 py-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                        />
                        {errors.get("confirmPassword") && <p className="text-red-500 text-sm">{errors.get("confirmPassword")}</p>}
                    </div>
                    <button
                        type="submit"
                        className="w-full px-4 py-2 font-medium text-white bg-indigo-600 rounded-md hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                    >
                        Register
                    </button>
                    <p>Already have an account? <Link to="/" className="text-blue-500 hover:underline">Login</Link></p>
                </form>
            </div>
        </div>
    );
})
