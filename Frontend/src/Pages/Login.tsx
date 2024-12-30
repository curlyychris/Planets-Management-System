import React, { useState } from "react";
import * as yup from "yup";
import { observer } from 'mobx-react-lite';
import { useStore } from '../Stores/storeContext';
import { Link, useNavigate } from "react-router";
import { getLoginDataDefaults } from "../Models/loginFormData";
import { getYupErrorMessages } from "../Utilities/yupUtils";
import { LoginDTO } from "../Models/login.dto";

const loginValidator=yup.object().shape({
    email:yup.string().email("Invalid email").required("Email is required"),
    password:yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character"
    )
    .required("Password is required"),
});


export const Login=observer(()=> {
  const [loginFormData,setLoginFormData]=useState(getLoginDataDefaults())
  const [errors,setErrors]=useState(new Map<string,string>());
  const { authStore } = useStore();
  const navigate=useNavigate();

      const handleChange=(e: React.ChangeEvent<HTMLInputElement>)=>{
          const {name,value}=e.target;
          setLoginFormData((prevData)=>{
              return {...prevData,[name]:value}
          })
      };
  
      const login=async (e:React.FormEvent<HTMLFormElement>)=>{
          e.preventDefault();    
          const validation=await getYupErrorMessages(loginValidator,loginFormData);   
          if(validation.size!=0)
          {
              setErrors(validation);
          }
          else
          { 
            const loginDto:LoginDTO={email:loginFormData.email,password:loginFormData.password}
            authStore.login(loginDto).then(()=>{
              navigate("/planet");
              console.log("THENNNNNNNN");
            }).catch(()=>{console.log("CATCHHHHHHHH")});
            setErrors(new Map());
          }
          console.log(validation);
      }
  return (
    <div className="flex items-center justify-center min-h-screen">
      <div className="w-full max-w-md p-8 space-y-6 bg-white rounded-lg shadow-lg">
        <h2 className="text-2xl font-bold text-center text-gray-800">
          Login
        </h2>
        <form onSubmit={login} className="space-y-4">
          {/* Email Field */}
          <div>
            <label
              htmlFor="email"
              className="block text-sm font-medium text-gray-700"
            >
              Email
            </label>
            <input
              id="email"
              name="email"
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter your email"
              value={loginFormData.email}
              onChange={handleChange}
              
            />
            {errors.get("email") && <p className="text-red-500 text-sm">{errors.get("email")}</p>}
          </div>

          {/* Password Field */}
          <div>
            <label
              htmlFor="password"
              className="block text-sm font-medium text-gray-700"
            >
              Password
            </label>
            <input
              type="password"
              id="password"
              name="password"
              value={loginFormData.password}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter your password"
            />
            {errors.get("password") && <p className="text-red-500 text-sm">{errors.get("password")}</p>}
          </div>

          {/* Submit Button */}
          <button
            type="submit"
            className="w-full px-4 py-2 text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:ring-4 focus:ring-blue-300"
          >
            Login
          </button>
          {authStore.hasError&& <p className="text-red-500 text-sm">Oopsies, seems that you entered wrong credentials</p>}
          <p>
            Don't have an account? <Link to="/register" className="text-blue-500 hover:underline">Register</Link>
          </p>
        </form>
      </div>
    </div>
  );
})
