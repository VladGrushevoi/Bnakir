import "./SubmitButton.css"

interface SubmitButtonProps {

}

export const SubmitButton = ({ }: SubmitButtonProps) => {

    return (
        <>
            <div className="block text-center text-3xl mt-4">
                <button type="submit" className="border 
                        py-4 px-6 
                        rounded-2xl font-bold tracking-widest
                        box-border shadow-2xl shadow-purple-600
                        bg-gradient-to-tr from-blue-400 to-violet-400 
                        hover:bg-gradient-to-tr hover:from-red-500 hover:to-orange-400 hover:-translate-y-4 hover:shadow-orange-600
                        duration-200 submitButton-animate"
                >
                    ПІДТВЕРДИТИ
                </button>
            </div>
        </>
    )
}