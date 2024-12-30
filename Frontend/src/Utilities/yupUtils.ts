import * as yup from "yup"

export async function getYupErrorMessages<T>(schema:yup.ObjectSchema<yup.AnyObject>,values:T): Promise <Map<string, string>>
{
    const validationError=new Map<string, string>()
    try{
        await schema.validate(values,{abortEarly:false});
    }catch(err)
    {
        if(err instanceof yup.ValidationError)
        {
            
            err.inner.forEach((error)=>{
                console.log(error)
                if (error.path) {
                    validationError.set(error.path, error.message)
                }
            })
        }
    }
    return validationError;
}