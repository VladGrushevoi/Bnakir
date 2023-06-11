interface HeaderProps {

}

export const Header = ({} : HeaderProps) => {

    return (
        <>
            <div 
                className="flex justify-center h-1/5 rounded-b-xl shadow-slate-400 shadow-md bg-lime-200 "
                >
                <h1 
                    className="w-full h-full pt-7 font-medium tracking-widest text-6xl font-mono text-center"
                    >
                        SHKLIFT
                </h1>
            </div>
        </>
    )
}