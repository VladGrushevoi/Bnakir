import { InputHandler } from "../Card/Card"

interface CvvInputProps {
    inputHook : InputHandler
}

export const CvvInput = ({inputHook} : CvvInputProps) => {
    return (
        <>
           <input 
                type="password"
                {...inputHook} 
                className=" w-12 px-2 border rounded-md text-2xl outline-none"
            
            /> 
        </>
    )
}