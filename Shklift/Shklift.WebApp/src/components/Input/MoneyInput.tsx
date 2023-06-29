import { InputHandler } from "../Card/Card"

interface MoneyInputProps {
    inputHook : InputHandler
}

export const MoneyInput = ({inputHook} : MoneyInputProps) => {

    return (
        <>
            <input 
                type="text" 
                {...inputHook} 
                maxLength={8} 
                pattern="[0-9]{1,8}" 
                className="rounded-lg w-1/4 px-4 mt-4" />
        </>
    )
}