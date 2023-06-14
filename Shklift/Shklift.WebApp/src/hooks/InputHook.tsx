import { useState } from "react"

export const useInput = (data : string) => {
    const [value, setValue] = useState(data);

    return {
        value: value,
        onChange: (e: React.ChangeEvent<HTMLInputElement>) => setValue(e.target.value)
    }
}