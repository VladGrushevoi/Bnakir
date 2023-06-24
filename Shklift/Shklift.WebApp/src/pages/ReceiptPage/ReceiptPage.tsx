import { ReceiptItem } from "../../components/ReceiptItem/ReceiptItem"
import "./ReceiptPage.css"

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
            <div className="w-[80%] h-[60%] m-auto mt-6 border rounded-2xl text-center justify-center shadow-md receipt-animation">
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
                <div className="w-full h-full flex py-6 px-6 text-center">
                    <ReceiptItem
                        title="Відправник" 
                        isSender={true} 
                        cardNumber={fakeData.fromCard} 
                        amountMoney={fakeData.amountMoney}
                        commission={fakeData.commission}
                        />
                    <span className="mx-2"></span>
                    <ReceiptItem
                        title="Отримувач" 
                        isSender={false}
                        cardNumber={fakeData.toCard}
                    />
                </div>
            </div>
        </>
    )
}