interface ReceiptItemProps {
    isSender: boolean,
    title: string,
    cardNumber: string,
    amountMoney?: number | string | null | undefined,
    commission?: number | string | null | undefined
}

export const ReceiptItem = ({ isSender, title, cardNumber, amountMoney, commission }: ReceiptItemProps) => {

    return (
        <>
            <div className="w-1/2 h-[80%] border rounded-lg p-4 shadow-md">
                <span className="block tracking-widest text-xl font-bold">{title}</span>
                <span className="block text-left py-4 text-gray-400">
                    Номер карти:
                    <span className="ml-4 font-bold text-black ">
                        {cardNumber.match(/.{1,4}/g)?.join(" ")}
                    </span>
                </span>
                {
                    isSender &&
                    <>
                        <span className="block text-left py-2 text-gray-400">
                            Кількість:
                            <span className="ml-4 font-bold text-black">
                                {amountMoney} грошей
                            </span>
                        </span>
                        <span className="block text-left py-2 text-gray-400">
                            Комісія:
                            <span className="ml-4 font-bold text-black">
                                {commission} грошей
                            </span>
                        </span>
                    </>
                }
            </div>
        </>
    )
}