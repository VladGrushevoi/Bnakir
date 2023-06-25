import { useState } from "react"

export const useInput = (data : string, name: string) => {
    const [value, setValue] = useState(data);

    return {
        value: value,
        name: name,
        onChange: (e: React.ChangeEvent<HTMLInputElement>) => setValue(e.target.value)
    }
}