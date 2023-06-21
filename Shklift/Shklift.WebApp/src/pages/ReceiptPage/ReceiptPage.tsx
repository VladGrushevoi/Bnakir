interface ReceiptPageProps {

}

export const ReceiptPage = ({} : ReceiptPageProps) => {

    return (
        <>
            <div className="w-[80%] h-[60%] m-auto mt-6 border rounded-2xl text-center justify-center  shadow-md ">
                <div className="block text-4xl mt-0 rounded-t-2xl py-2 bg-green-300">
                    <span className="w-full h-full rounded-full mx-4 px-3 font-extrabold text-red-500 bg-red-800">X</span>
                    <span className="tracking-widest font-semibold">КВИТАНЦІЯ</span>
                </div>
                <div className="w-full h-full flex mt-6 px-6 text-center">
                    <div className="w-1/2 h-[80%] border rounded-lg">
                        <span className="block">Відправник</span>
                    </div>
                    <span className="mx-2"></span>
                    <div className="w-1/2 h-[80%] border rounded-l">
                        <span className="block">Отримувач</span>
                    </div>
                </div>
            </div>
        </>
    )
}