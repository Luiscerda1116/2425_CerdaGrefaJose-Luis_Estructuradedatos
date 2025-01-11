from datetime import datetime
import json
import os


class Contacto:
    def __init__(self, nombre, telefono, email="", direccion=""):
        self.nombre = nombre
        self.telefono = telefono
        self.email = email
        self.direccion = direccion
        self.fecha_registro = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

    def to_dict(self):
        return {
            "nombre": self.nombre,
            "telefono": self.telefono,
            "email": self.email,
            "direccion": self.direccion,
            "fecha_registro": self.fecha_registro
        }


class AgendaTelefonica:
    def __init__(self):
        self.contactos = []
        self.archivo_datos = "contactos.json"
        self.cargar_datos()

    def agregar_contacto(self, nombre, telefono, email="", direccion=""):
        if not self.buscar_contacto(telefono):
            nuevo_contacto = Contacto(nombre, telefono, email, direccion)
            self.contactos.append(nuevo_contacto)
            self.guardar_datos()
            return True
        return False

    def eliminar_contacto(self, telefono):
        for i, contacto in enumerate(self.contactos):
            if contacto.telefono == telefono:
                del self.contactos[i]
                self.guardar_datos()
                return True
        return False

    def buscar_contacto(self, telefono):
        for contacto in self.contactos:
            if contacto.telefono == telefono:
                return contacto
        return None

    def listar_contactos(self):
        return sorted(self.contactos, key=lambda x: x.nombre)

    def guardar_datos(self):
        datos = [contacto.to_dict() for contacto in self.contactos]
        with open(self.archivo_datos, 'w', encoding='utf-8') as f:
            json.dump(datos, f, indent=4, ensure_ascii=False)

    def cargar_datos(self):
        try:
            with open(self.archivo_datos, 'r', encoding='utf-8') as f:
                datos = json.load(f)
                self.contactos = [
                    Contacto(
                        d["nombre"],
                        d["telefono"],
                        d.get("email", ""),
                        d.get("direccion", "")
                    ) for d in datos
                ]
        except FileNotFoundError:
            self.contactos = []


def mostrar_contacto(contacto):
    print(f"\nNombre: {contacto.nombre}")
    print(f"Teléfono: {contacto.telefono}")
    print(f"Email: {contacto.email}")
    print(f"Dirección: {contacto.direccion}")
    print("-" * 30)


# Código de prueba
def ejecutar_pruebas():
    print("=== INICIANDO PRUEBAS DE AGENDA TELEFÓNICA ===\n")

    # Crear instancia de agenda
    agenda = AgendaTelefonica()

    # Limpiar archivo previo si existe
    if os.path.exists("contactos.json"):
        os.remove("contactos.json")

    # 1. Prueba: Agregar contactos
    print("1. Agregando contactos de prueba...")
    agenda.agregar_contacto("Juan Pérez", "099123456", "juan@email.com", "Av. Principal 123")
    agenda.agregar_contacto("María López", "098765432", "maria@email.com", "Calle 456")
    print("✓ Contactos agregados exitosamente")

    # 2. Prueba: Listar contactos
    print("\n2. Listando todos los contactos:")
    for contacto in agenda.listar_contactos():
        mostrar_contacto(contacto)

    # 3. Prueba: Buscar contacto
    print("\n3. Buscando contacto por teléfono...")
    contacto = agenda.buscar_contacto("099123456")
    if contacto:
        print("✓ Contacto encontrado:")
        mostrar_contacto(contacto)

    # 4. Prueba: Eliminar contacto
    print("\n4. Eliminando contacto...")
    if agenda.eliminar_contacto("098765432"):
        print("✓ Contacto eliminado exitosamente")

    # 5. Prueba: Verificar lista final
    print("\n5. Lista final de contactos:")
    for contacto in agenda.listar_contactos():
        mostrar_contacto(contacto)

    print("\n=== PRUEBAS COMPLETADAS EXITOSAMENTE ===")


if __name__ == "__main__":
    ejecutar_pruebas()

