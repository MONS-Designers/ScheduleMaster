import Header from "./Header"
import Section from "./Section"

export const Layout = () =>{
    return(
        <div style={{display:'flex', flexDirection:'column'}}>
            <Header />
            <Section />
        </div>
    )
}