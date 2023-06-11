interface CardInputProps {

}

export const CardInput = ({} : CardInputProps) => {
    return (
        <>
            <input type="text" maxLength={4} pattern="[0-9]{4}" className="mx-2 w-20 border rounded-md text-4xl"/>
        </>
    )
}