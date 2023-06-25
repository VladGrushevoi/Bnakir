import { InputHandler } from "../Card/Card"

interface DateInputProps {
    inputHook : InputHandler[]
}

export const DateInput = ({inputHook} : DateInputProps) => {

    return (
        <>
            <input 
                type="text" 
                {...inputHook[0]}  
                className=" w-8 border rounded-md text-2xl outline-none"
                minLength={2}
                maxLength={2}
                pattern="[0-9]{2}"
                />
            <span className="text-2xl">/</span>
            <input 
                type="text" 
                {...inputHook[1]} 
                className="w-8 border rounded-md text-2xl outline-none"
                minLength={2}
                maxLength={2}
                pattern="[0-9]{2}"
                />
        </>
    )
}