interface ReceiptPageProps {

}

const fakeData = {
    status: true,
    fromCard: "1111222233335555",
    toCard: "3333444455556666",
    amountMoney: 350,
    commission: 35

}

export const ReceiptPage = ({} : ReceiptPageProps) => {

    return (
        <>
            <div className="w-[80%] h-[60%] m-auto mt-6 border rounded-2xl text-center justify-center  shadow-md ">
                <div className={`block text-4xl mt-0 rounded-t-2xl py-2 ${fakeData.status ? 'bg-green-300' : 'bg-red-300'}`}>
                {
                            fakeData.status ? 
                            <img 
                                src="https://img.icons8.com/?size=512&id=EmPTDMRlslbb&format=png" 
                                alt="" 
                                className="w-10 h-10 inline p-0 mb-2"
                                />
                            :
                            <img 
                                src="https://img.icons8.com/?size=512&id=MmVr5QVBaT-5&format=png" 
                                alt="" 
                                className="w-10 h-10 inline p-0 mb-2"
                                />
                        }
                    <span className="tracking-widest font-semibold">КВИТАНЦІЯ</span>
                </div>
                <div className="w-full h-full flex mt-6 px-6 text-center">
                    <div className="w-1/2 h-[80%] border rounded-lg">
                        <span className="block tracking-widest text-xl">Відправник</span>
                        <span className="block">
                            Номер карти:
                            <span>{fakeData.fromCard}</span>    
                        </span>
                        <span className="block ">
                            Кількість:
                            <span>{fakeData.amountMoney} грошей</span>
                        </span>
                        <span className="block">
                            Комісія:
                            <span>{fakeData.commission} грошей</span>
                        </span>
                    </div>
                    <span className="mx-2"></span>
                    <div className="w-1/2 h-[80%] border rounded-l">
                        <span className="block tracking-widest text-xl">Отримувач</span>
                        <span className="block">
                            Номер карти:
                            <span>{fakeData.toCard}</span>    
                        </span>
                    </div>
                </div>
            </div>
        </>
    )
}