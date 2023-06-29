import { InputHandler } from "../Card/Card"

interface CardInputProps {
    inputHook : InputHandler
}

export const CardInput = ({inputHook} : CardInputProps) => {
    return (
        <>
            <input 
                minLength={4}
                maxLength={4}
                pattern="[0-9]{4}"
                type="text"
                {...inputHook}
                className="mx-2 w-20 border rounded-md text-4xl"/>
        </>
    )
}