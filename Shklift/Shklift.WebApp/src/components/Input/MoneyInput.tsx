interface MoneyInputProps {

}

export const MoneyInput = ({} : MoneyInputProps) => {

    return (
        <>
            <input type="text" maxLength={8} className="rounded-lg w-1/4 px-4 mt-4" />
        </>
    )
}