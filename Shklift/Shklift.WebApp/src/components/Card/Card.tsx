import { CardInput } from "../Input/CardInput"
import { CvvInput } from "../Input/CvvInput"
import { DateInput } from "../Input/DateInput"
import { MoneyInput } from "../Input/MoneyInput"
import "./Card.css"

interface CardProps {
    isSender: boolean,
    title: string
}

export const Card = ({ isSender, title }: CardProps) => {
    return (
        <>
            <div
                className={`w-[550px] 
                            h-[350px] mb-6 
                            bg-slate-200 
                            m-auto border 
                            rounded-3xl 
                            shadow-lg 
                            hover:shadow-pink-300 
                            hover:-translate-y-4  
                            ${isSender ? "card-animate-left" : "card-animate-right"}`}
            >
                <div className="block mt-8 w-full h-16 bg-black pt-2">
                    <div className="text-center text-3xl text-yellow-100 tracking-widest"><h1>{title}</h1></div>
                </div>
                <div className="cardInput-animate">
                    <div className="mt-8">
                        <p className="block text-center text-2xl">Номер банківської карти</p>
                        <div className="flex w-full h-10 justify-center">
                            <CardInput />
                            <CardInput />
                            <CardInput />
                            <CardInput />
                        </div>
                    </div>
                    {
                        isSender && <>
                            <div className="flex w-full h-10 justify-center mt-8">
                                <span
                                >
                                    <span className="text-2xl mr-2">Дата</span>
                                    <DateInput />
                                </span>
                                <span className="mx-12"></span>
                                <span
                                >
                                    <span className="text-2xl mr-2">CVV</span>
                                    <CvvInput />
                                </span>
                            </div>
                            <span className="inline-block w-full text-center text-2xl">
                                    Сума
                                    <span className="mx-2"></span>
                                    <MoneyInput />
                                    <span className="mx-2"></span>
                                    грошей
                                </span>
                        </>
                    }
                </div>
            </div>
        </>
    )
}