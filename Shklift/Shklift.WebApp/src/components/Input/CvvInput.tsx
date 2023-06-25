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
                minLength={3}
                maxLength={3}
                pattern="[0-9]{3}" 
                className=" w-12 px-2 border rounded-md text-2xl outline-none"
            
            /> 
        </>
    )
}