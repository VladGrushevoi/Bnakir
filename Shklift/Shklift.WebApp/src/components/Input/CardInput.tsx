import { InputHandler } from "../Card/Card"

interface CardInputProps {
    inputHook : InputHandler
}

export const CardInput = ({inputHook} : CardInputProps) => {
    return (
        <>
            <input 
                type="text"
                {...inputHook} 
                maxLength={4} 
                pattern="[0-9]{4}" 
                className="mx-2 w-20 border rounded-md text-4xl"/>
        </>
    )
}