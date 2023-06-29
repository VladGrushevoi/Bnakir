import { TransactionResponse } from "../../axios/axios";
import { ReceiptItem } from "../../components/ReceiptItem/ReceiptItem"
import "./ReceiptPage.css"

interface ReceiptPageProps {
    transactionData : TransactionResponse
}

export const ReceiptPage = ({ transactionData } : ReceiptPageProps) => {   
    console.log(transactionData, "receipt page")
    return (
        <>
            <div className="w-[80%] h-[60%] m-auto mt-6 border rounded-2xl text-center justify-center shadow-md receipt-animation">
                <div className={`block text-4xl mt-0 rounded-t-2xl py-2 ${transactionData.IsConfirmTransaction ? 'bg-green-300' : 'bg-red-300'}`}>
                {
                            transactionData.IsConfirmTransaction ? 
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
                        cardNumber={transactionData.FromCardNumber!} 
                        amountMoney={transactionData.AmountMoney!}
                        commission={transactionData.Commission!}
                        />
                    <span className="mx-2"></span>
                    <ReceiptItem
                        title="Отримувач" 
                        isSender={false}
                        cardNumber={transactionData.ToCardNumber!}
                    />
                </div>
            </div>
        </>
    )
}