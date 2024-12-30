import React, { useState } from 'react';
import * as yup from 'yup';
import { getYupErrorMessages } from '../Utilities/yupUtils';
import { CreatePlanetFormData } from '../Models/createPlanetFormData';

interface Props
{
  onClose:()=>void,
  onCreate:(createPlanetFormData:CreatePlanetFormData)=>void
}

const planetSchema = yup.object().shape({
  name: yup.string().required('Name is required'),
  rotation_period: yup.string().required('Rotation period is required'),
  orbital_period: yup.string().required('Orbital period is required'),
  diameter: yup.string().required('Diameter is required'),
  climate: yup.string().required('Climate is required'),
  gravity: yup.string().required('Gravity is required'),
});

const CreatePlanetForm = ({onClose,onCreate}:Props) => {
  const [formData, setFormData] = useState<CreatePlanetFormData>({
    name: '',
    rotation_period: '',
    orbital_period: '',
    diameter: '',
    climate: '',
    gravity: '',
  });

  const [errors, setErrors] = useState<Map<string, string>>(new Map());

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };



  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const errors = await getYupErrorMessages(planetSchema,formData);
    if (errors.size==0) {
      onCreate(formData);
    }
    else{
      setErrors(errors);
    }
  };
  return (
      <div className="p-8 space-y-6 bg-white rounded-lg shadow-lg">
        <h2 className="text-2xl font-bold text-center text-gray-800">Create Planet</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label htmlFor="name" className="block text-sm font-medium text-gray-700">Name</label>
            <input
              id="name"
              name="name"
              type="text"
              value={formData.name}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter planet name"
            />
            {errors.get("name") && <p className="text-red-500 text-sm">{errors.get("name")}</p>}
          </div>
          <div>
            <label htmlFor="rotation_period" className="block text-sm font-medium text-gray-700">Rotation Period</label>
            <input
              id="rotation_period"
              name="rotation_period"
              type="text"
              value={formData.rotation_period}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter rotation period"
            />
            {errors.get("rotation_period") && <p className="text-red-500 text-sm">{errors.get("rotation_period")}</p>}
          </div>
          <div>
            <label htmlFor="orbital_period" className="block text-sm font-medium text-gray-700">Orbital Period</label>
            <input
              id="orbital_period"
              name="orbital_period"
              type="text"
              value={formData.orbital_period}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter orbital period"
            />
            {errors.get("orbital_period") && <p className="text-red-500 text-sm">{errors.get("orbital_period")}</p>}
          </div>
          <div>
            <label htmlFor="diameter" className="block text-sm font-medium text-gray-700">Diameter</label>
            <input
              id="diameter"
              name="diameter"
              type="text"
              value={formData.diameter}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter diameter"
            />
            {errors.get("diameter") && <p className="text-red-500 text-sm">{errors.get("diameter")}</p>}
          </div>
          <div>
            <label htmlFor="climate" className="block text-sm font-medium text-gray-700">Climate</label>
            <input
              id="climate"
              name="climate"
              type="text"
              value={formData.climate}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter climate"
            />
            {errors.get("climate") && <p className="text-red-500 text-sm">{errors.get("climate")}</p>}
          </div>
          <div>
            <label htmlFor="gravity" className="block text-sm font-medium text-gray-700">Gravity</label>
            <input
              id="gravity"
              name="gravity"
              type="text"
              value={formData.gravity}
              onChange={handleChange}
              className="w-full px-4 py-2 mt-1 text-sm border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"
              placeholder="Enter gravity"
            />
            {errors.get("gravity") && <p className="text-red-500 text-sm">{errors.get("gravity")}</p>}
          </div>
          <button
            type="submit"
            className="w-full px-4 py-2 text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:ring-4 focus:ring-blue-300"
          >
            Create Planet
          </button>
          <button
              type="button"
              onClick={onClose}
              className="w-full px-4 py-2  text-white bg-red-500 rounded-lg hover:bg-red-600 focus:ring-4 focus:ring-red-300"
            >
              Close
            </button>
          
        </form>
      </div>
  );
};

export default CreatePlanetForm;