import fs from "fs";
import path from "path";
import { fileURLToPath } from "url";

// Convertir __dirname para ES Modules
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Función para crear un componente
function createComponent(componentName, destination = ".") {
  // Ruta absoluta del destino
  const componentPath = path.resolve(destination, componentName);

  // Verificar si la carpeta ya existe
  if (fs.existsSync(componentPath)) {
    console.error(`❌ La carpeta "${componentName}" ya existe en "${destination}".`);
    return;
  }

  // Crear carpeta del componente
  fs.mkdirSync(componentPath, { recursive: true });
  console.log(`📂 Carpeta creada: ${componentPath}`);

  // Crear archivo .tsx
  const tsxContent = `import "./${componentName}Component.css";

function ${componentName}Component() {
  return (
    <div className="${componentName.toLowerCase()}">
      <h3>${componentName} Component</h3>
    </div>
  );
};

export default ${componentName}Component;
`;
  fs.writeFileSync(path.join(componentPath, `${componentName}Component.tsx`), tsxContent);
  console.log(`✅ Archivo creado: ${componentName}Component.tsx`);

  // Crear archivo .css
  const cssContent = `.${componentName.toLowerCase()} {
  /* Estilos para el componente ${componentName}Component */
}
`;
  fs.writeFileSync(path.join(componentPath, `${componentName}Component.css`), cssContent);
  console.log(`✅ Archivo creado: ${componentName}Component.css`);
}

// Función para procesar múltiples componentes
function createComponents(componentNames, destination) {
  componentNames.forEach((componentName) => {
    createComponent(componentName, destination);
  });
}

// Obtener argumentos de la línea de comandos
const args = process.argv.slice(2);

if (args.length === 0) {
  console.error("❌ Uso: node create-component.js <NombreComponente1> [NombreComponente2 ...] [RutaDestino]");
  process.exit(1);
}

// Separar componentes y ruta de destino
let destination = ".";
const components = args.filter((arg) => !arg.startsWith(".") && !arg.includes("/"));
const possibleDestination = args.find((arg) => arg.startsWith(".") || arg.includes("/"));

if (possibleDestination) {
  destination = possibleDestination;
}

// Crear componentes
createComponents(components, destination);