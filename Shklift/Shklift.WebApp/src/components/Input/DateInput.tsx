interface DateInputProps {

}

export const DateInput = ({} : DateInputProps) => {

    return (
        <>
            <input type="text"  className=" w-8 border rounded-md text-2xl outline-none"/>
            <span className="text-2xl">/</span>
            <input type="text" className="w-8 border rounded-md text-2xl outline-none"/>
        </>
    )
}